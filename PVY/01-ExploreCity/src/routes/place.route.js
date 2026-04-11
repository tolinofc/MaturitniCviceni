import express from "express";
import * as placeController from "../controllers/place.controller.js";

const router = express.Router();

router.get('/:id', placeController.getPlace)
router.get('/:id/rating', placeController.getRatingsByPlace)
router.get('/:id/comment', placeController.getCommentsByPlace)
router.get('/:id/average-rating', placeController.getAverageRating)
router.post('/', placeController.addPlace)
router.put('/:id', placeController.updatePlace)
router.delete('/:id', placeController.deletePlace)

export default router;