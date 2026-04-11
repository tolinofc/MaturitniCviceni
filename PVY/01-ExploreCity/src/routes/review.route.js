import express from 'express'
import * as reviewController from "../controllers/review.controller.js";

const router = express.Router()

router.get('/rating/:id', reviewController.getRating)
router.get('/comment/:id', reviewController.getComment)
router.post('/place/rating/:placeId', reviewController.addRating)
router.post('/place/comment/:placeId', reviewController.addComment)
router.delete('/rating/:id', reviewController.deleteRating)
router.delete('/comment/:id', reviewController.deleteComment)

export default router