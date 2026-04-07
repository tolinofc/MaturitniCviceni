import {pool} from "../db.js";

export async function getPlace(id) {
    const [data, metadata] = await pool.execute('SELECT     p.name AS place_name,     p.description AS place_description,     p.address AS place_address,     c.name AS city_name,     t.name AS type_name FROM     place p INNER JOIN city c ON     c.id = p.cityId INNER JOIN type t ON     t.id = p.typeId WHERE     p.id = ?', [
        id
    ])

    return data;
}

export async function getReviewsByPlace(id) {
    const [data, metadata] = await pool.execute('SELECT p.name AS place_name, p.description AS place_description, p.address AS place_address, r.author as rating_author, r.added_date as rating_date, r.rating as rating_number, r.comment as rating_comment FROM review r INNER JOIN place p ON p.id = r.placeId WHERE p.id = ? order by added_date desc', [
        id
    ])

    return data
}

export async function addPlace(place) {
    const [result] = await pool.execute('INSERT INTO `place`(`id`, `cityId`, `typeId`, `name`, `description`, `address`) VALUES (default,?,?,?,?,?)', [
        place.cityId,
        place.typeId,
        place.name,
        place.description,
        place.address
    ])

    console.log('inserted place id: ' + result.insertId)

    return result.insertId
}

export async function getAverageRating(placeId) {
    const [data, metadata] = await pool.execute('SELECT AVG(rating) AS average_rating, COUNT(id) AS review_count FROM review WHERE placeId = ?', [
        placeId
    ])

    return data
}

export async function updatePlace(place) {
    const [result] = await pool.execute(`UPDATE
                                             place
                                         SET \`cityId\`      = ?,
                                             \`typeId\`      = ?,
                                             \`name\`        = ?,
                                             \`description\` = ?,
                                             \`address\`     = ?
                                         WHERE id = ?`, [
        place.cityId,
        place.typeId,
        place.name,
        place.description,
        place.address,
        place.id
    ])

    return result.affectedRows
}

export async function deletePlace(placeId) {
    await pool.execute('DELETE FROM place where id = ?', [
        placeId
    ])
}