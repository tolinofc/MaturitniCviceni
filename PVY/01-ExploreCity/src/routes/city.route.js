import express from "express";
import * as cityController from "../controllers/city.controller.js";

const router = express.Router();

router.get('/', cityController.getCities)
router.get('/:id', cityController.getCity)
router.get('/:id/places', cityController.getPlacesByCity)

export default router;