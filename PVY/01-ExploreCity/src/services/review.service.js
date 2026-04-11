import {pool} from '../db.js'

export async function getRating(id) {
    const [data, metadata] = await pool.execute('select * from rating where id = ?', [
        id
    ])

    return data[0]
}

export async function getComment(id) {
    const [data, metadata] = await pool.execute('select * from comment where id = ?', [
        id
    ])

    return data[0]
}

export async function addRating(rating) {
    const [result] = await pool.execute('INSERT INTO rating (`id`, `placeId`, `rating`) VALUES (default,?,?)', [
        rating.placeId,
        rating.rating
    ])

    return result.insertId
}

export async function addComment(comment) {
    const [result] = await pool.execute('INSERT INTO comment (`id`, `placeId`, `author`, `added_date`, `comment`) VALUES (default,?,?,NOW(),?)', [
        comment.placeId,
        comment.author,
        comment.comment
    ])

    return result.insertId
}


export async function deleteComment(id) {
    await pool.execute('DELETE FROM comment where id = ?', [
        id
    ])
}

export async function deleteRating(id) {
    await pool.execute('DELETE FROM rating where id = ?', [
        id
    ])
}