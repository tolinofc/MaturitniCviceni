import {pool} from "../db.js";

export async function getCities() {
    const [data, metadata] = await pool.execute('SELECT * FROM city order by name asc')

    return data
}

export async function getCity(id) {
    const [data, metadata] = await pool.execute('SELECT * FROM city where id = ?', [
        id
    ])

    return data[0]
}

export async  function getPlacesByCity(cityId) {
    const [data, metadata] = await pool.execute('SELECT c.name AS city_name, p.name AS place_name, p.description AS place_description, p.address AS place_address, t.name AS type_name FROM place p INNER JOIN city c ON c.id = p.cityId INNER JOIN type t ON t.id = p.typeId WHERE c.id = ? ORDER BY p.name ASC', [
        cityId
    ])

    return data
}