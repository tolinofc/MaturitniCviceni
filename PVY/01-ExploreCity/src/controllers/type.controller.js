import * as typeService from '../services/type.service.js'

export async function getTypes(req, res) {
    const type = await typeService.getTypes()

    res.json(type)
}