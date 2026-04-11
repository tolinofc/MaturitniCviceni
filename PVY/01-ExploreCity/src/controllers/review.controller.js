import * as reviewService from "../services/review.service.js";

export async function getRating(req, res) {
    const id = req.params.id
    const rating = await reviewService.getRating(id)

    if (!rating) {
        return res.status(404).json()
    }

    res.json(rating)
}

export async function getComment(req, res) {
    const id = req.params.id
    const comment = await reviewService.getComment(id)

    if (!comment) {
        return res.status(404).json()
    }

    res.json(comment)
}

export async function addRating(req, res) {
    const newRating = {
        placeId: req.params.placeId,
        rating: req.body.rating
    }

    const ratingId = await reviewService.addRating(newRating)

    const rating = await reviewService.getRating(ratingId)

    res.json(rating)
}

export async function addComment(req, res) {
    const newComment = {
        placeId: req.params.placeId,
        author: req.body.author,
        comment: req.body.comment
    }

    const commentId = await reviewService.addComment(newComment)

    const comment = await reviewService.getComment(commentId)

    res.json(comment)
}

export async function deleteRating(req, res){
    const id = req.params.id

    await reviewService.deleteRating(id)

    res.status(200).send()
}

export async function deleteComment(req, res){
    const id = req.params.id

    await reviewService.deleteComment(id)

    res.status(200).send()
}