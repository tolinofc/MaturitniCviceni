import express from "express";
import * as typeController from '../controllers/type.controller.js'

const router =  express.Router()

router.get('/', typeController.getTypes)

export default router