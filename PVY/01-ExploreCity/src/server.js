import express from 'express'
import cityRoutes from './routes/city.route.js'
import placeRoutes from './routes/place.route.js'
import reviewRoutes from './routes/review.route.js'

const app = express();

app.use(express.static('public'))
app.use(express.json());

app.use((req, res, next) => {
    console.log(req.method, req.url, req.query, req.body);
    next();
});

app.use('/city', cityRoutes)
app.use('/place', placeRoutes)
app.use('/review', reviewRoutes)

app.use((req, res) => {
    res.status(404)
        .json({
            error: 'NOT_FOUND'
        })
})

app.listen(3000, () => {
    console.log('Express server running on http://localhost:3000')
});