import {pool} from "../db.js";

export async function getPlace(id) {
    const [data, metadata] = await pool.execute('SELECT     p.name AS place_name,     p.description AS place_description,     p.address AS place_address,     c.name AS city_name,     t.name AS type_name, t.id AS type_id, p.image_path as image_path FROM     place p INNER JOIN city c ON     c.id = p.cityId INNER JOIN type t ON     t.id = p.typeId WHERE     p.id = ?', [
        id
    ])

    return data[0];
}

export async function getRatingsByPlace(id) {
    const [data, metadata] = await pool.execute('SELECT  r.id, r.rating FROM rating r INNER JOIN place p ON p.id = r.placeId WHERE placeId = ?', [
        id
    ])

    return data
}

export async function getCommentsByPlace(id) {
    const [data, metadata] = await pool.execute('SELECT  c.id,     c.author AS rating_author,     c.added_date AS rating_date,     c.comment FROM     comment c INNER JOIN place p ON     p.id = c.placeId WHERE     p.id = ? ORDER BY added_date DESC, c.id DESC     ', [
        id
    ])

    return data
}

export async function addPlace(place) {
    const [result] = await pool.execute('INSERT INTO `place`(`id`, `cityId`, `typeId`, `name`, `description`, `address`, `image_path`) VALUES (default,?,?,?,?,?,?)', [
        place.cityId,
        place.typeId,
        place.name,
        place.description,
        place.address,
        place.imagePath
    ])

    console.log('inserted place id: ' + result.insertId)

    return result.insertId
}

export async function getAverageRating(placeId) {
    const [data, metadata] = await pool.execute('SELECT AVG(rating) AS average_rating, COUNT(id) AS review_count FROM rating WHERE placeId = ?', [
        placeId
    ])

    return data[0]
}

export async function updatePlace(place) {
    const [result] = await pool.execute(`UPDATE
                                             place
                                         SET \`cityId\`      = ?,
                                             \`typeId\`      = ?,
                                             \`name\`        = ?,
                                             \`description\` = ?,
                                             \`address\`     = ?,
                                             \`image_path\` = ?
                                         WHERE id = ?`, [

        place.cityId,
        place.typeId,
        place.name,
        place.description,
        place.address,
        place.imagePath,
        place.id
    ])

    return result.affectedRows
}

export async function deletePlace(placeId) {
    await pool.execute('DELETE FROM comment where placeId = ?', [
        placeId
    ])

    await pool.execute('DELETE FROM rating where placeId = ?', [
        placeId
    ])

    await pool.execute('DELETE FROM place where id = ?', [
        placeId
    ])
}