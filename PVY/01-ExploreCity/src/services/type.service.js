import {pool} from '../db.js'

export async function getTypes() {
    const [data, metadata] = await pool.execute('select * from type')

    return data
}