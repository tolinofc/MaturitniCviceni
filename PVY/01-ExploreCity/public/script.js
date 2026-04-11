const citiesContainer = document.querySelector('.cities')
const placesContainer = document.querySelector('.city-detail')
const cityTemplate = document.querySelector('#city-template')
const placeTemplate = document.querySelector('#place-template')
const placeDetailTemplate = document.querySelector("#place-detail-template")
const commentTemplate = document.querySelector('#comment-template')

async function getCities() {
    const res = await fetch('/city')
    const cities = await res.json()

    cities.forEach(c => {
        const clone = cityTemplate.content.cloneNode(true)

        const div = clone.querySelector('.city')
        const img = clone.querySelector('img')
        const p = clone.querySelector('.city-name')

        div.dataset.cityId = c.id
        img.src = c.image_path
        p.textContent = c.name

        div.addEventListener('click', () => {
            getPlaces(c.id)
        })

        citiesContainer.appendChild(clone)
    })
}

async function getPlaces(id) {
    placesContainer.innerHTML = ''

    const res = await fetch(`/city/${id}/places`)
    const places = await res.json()

    places.forEach(p => {
        const clone = placeTemplate.content.cloneNode(true)

        const div = clone.querySelector('.place')
        const img = clone.querySelector('img')
        const placeName = clone.querySelector('.place-name')
        const placeType = clone.querySelector('.place-type')

        div.addEventListener('click', () => {
            getPlaceDetail(p.place_id)
        })

        img.src = 'https://placehold.co/600x400'
        placeName.textContent = p.place_name
        placeType.textContent = p.type_name

        placesContainer.appendChild(clone)
    })
}

async function getPlaceDetail(id) {
    const resPlace = await fetch(`/place/${id}`)
    const place = await resPlace.json()

    const resAverageRating = await fetch(`/place/${id}/average-rating`)
    const averageRating = await resAverageRating.json()

    const resComments = await fetch(`/place/${id}/comment`)
    const comments = await resComments.json()

    const clone = placeDetailTemplate.content.cloneNode(true)

    clone.querySelector('img').src = 'https://placehold.co/600x400'
    clone.querySelector('.place-title').textContent = place.place_name
    clone.querySelector('.place-description').textContent = place.place_description
    clone.querySelector('.place-address').textContent = place.place_address

    clone.querySelector('.btn-close').addEventListener('click', () => {
        document.body.querySelector('.place-detail').remove()
    })

    const rating = clone.querySelector('.rating')
    let numberOfStars = Math.round(averageRating.average_rating)
    for (let i = 0; i < 5; i++) {
        let div = document.createElement('div')
        if (i < numberOfStars) {
            div.textContent = '🌟'
        } else {
            div.textContent = '⭐'
        }
        rating.appendChild(div)
    }

    const ratingCount = document.createElement('div')
    ratingCount.textContent = `(${averageRating.review_count})`
    rating.appendChild(ratingCount)

    const commentsContainer = clone.querySelector('.comments')
    comments.forEach(c => {
        let divComment = commentTemplate.content.cloneNode(true)

        divComment.querySelector('.person-name').textContent = c.rating_author
        divComment.querySelector('.person-date').textContent = c.rating_date
        divComment.querySelector('.comment-text').textContent = c.comment

        divComment.querySelector('.btn-delete-comment').addEventListener('click', async () => {
            await fetch(`/review/comment/${c.id}`, {
                method: 'delete'
            })

            document.body.querySelector('.place-detail').remove()
            await getPlaceDetail(id)
        })

        commentsContainer.appendChild(divComment)
    })

    const newCommentInputName = clone.querySelector('.input-name')
    const newCommentInputText = clone.querySelector('.input-text')
    const newCommentBtn = clone.querySelector('.btn-send')

    newCommentBtn.addEventListener('click', async () => {
        const data = {
            author: newCommentInputName.value,
            comment: newCommentInputText.value
        }

        const response = await fetch(`/review/place/comment/${id}`, {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(data)
        })

        if (response.ok) {
            document.body.querySelector('.place-detail').remove()
            await getPlaceDetail(id)
        }
    })

    document.body.appendChild(clone)
}

getCities()