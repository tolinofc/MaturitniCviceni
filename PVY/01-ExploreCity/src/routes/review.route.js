import express from 'express'
import * as reviewController from "../controllers/review.controller.js";

const router = express.Router()

router.get('/:id', reviewController.getReview)
router.post('/place/:id/reviews', reviewController.addReview)
router.delete('/:id', reviewController.deleteReview)

export default router