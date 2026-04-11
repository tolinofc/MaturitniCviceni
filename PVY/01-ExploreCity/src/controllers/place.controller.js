import * as placeService from "../services/place.service.js";

export async function getPlace(req, res) {
    const id = req.params.id
    const place = await placeService.getPlace(id)

    if (!place) {
        return res.status(404).json()
    }

    res.json(place)
}

export async function getRatingsByPlace(req, res) {
    const id = req.params.id
    const ratings = await placeService.getRatingsByPlace(id)

    res.json(ratings)
}

export async function getCommentsByPlace(req, res) {
    const id = req.params.id
    const comments = await placeService.getCommentsByPlace(id)

    res.json(comments)
}


export async function addPlace(req, res) {
    const newPlace = {
        cityId: req.body.cityId,
        typeId: req.body.typeId,
        name: req.body.name,
        description: req.body.description,
        address: req.body.address
    }

    const placeId = await placeService.addPlace(newPlace)

    const place = await placeService.getPlace(placeId)

    res.json(place)
}

export async function updatePlace(req, res) {
    const newPlace = {
        "cityId": req.body.cityId,
        "typeId": req.body.typeId,
        "name": req.body.name,
        "description": req.body.description,
        "address": req.body.address,
        "id": req.params.id
    }

    await placeService.updatePlace(newPlace)

    res.status(204).send()
}

export async function getAverageRating(req, res) {
    const placeId = req.params.id

    const avgRating = await placeService.getAverageRating(placeId)

    res.json(avgRating)
}

export async function deletePlace(req, res) {
    const placeId = req.params.id

    await placeService.deletePlace(placeId)

    res.status(200).send()
}