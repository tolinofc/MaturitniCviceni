import {pool} from '../db.js'

export async function getReview(id) {
    const [data, metadata] = await pool.execute('select * from review where id = ?', [
        id
    ])

    return data
}

export async function addReview(review) {
    const [result] = await pool.execute('INSERT INTO review (`id`, `placeId`, `author`, `added_date`, `rating`, `comment`) VALUES (default,?,?,NOW(),?,?)', [
        review.placeId,
        review.author,
        review.rating,
        review.comment
    ])

    return result.insertId
}


export async function deleteReview(id) {
    await pool.execute('DELETE FROM review where id = ?', [
        id
    ])
}