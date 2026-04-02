import * as reviewService from "../services/review.service.js";

export async function getReview(req, res) {
    const id = req.params.id
    const review = await reviewService.getReview(id)

    res.json(review)
}

export async function addReview(req, res) {
    const newReview = {
        placeId: req.params.placeId,
        author: req.body.author,
        rating: req.body.rating,
        comment: req.body.comment
    }

    const reviewId = await reviewService.addReview(newReview)

    const review = await reviewService.getReview(reviewId)

    res.json(review)
}

export async function deleteReview(req, res){
    const id = req.params.id

    await reviewService.deleteReview(id)

    res.status(200).send()
}