import * as cityService from '../services/city.service.js'

export async function getCities(req, res) {
    const city = await cityService.getCities()

    res.json(city)
}

export async function getCity(req, res) {
    const id = req.params.id
    const city = await cityService.getCity(id)

    if (!city) {
        return res.status(404).json()
    }

    res.json(city)
}

export async function getPlacesByCity(req, res) {
    const id = req.params.id
    const places = await cityService.getPlacesByCity(id)

    res.json(places)
}