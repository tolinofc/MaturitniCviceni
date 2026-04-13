const citiesContainer = document.querySelector('.cities')
const placesContainer = document.querySelector('.city-detail')
const cityTemplate = document.querySelector('#city-template')
const placeTemplate = document.querySelector('#place-template')
const placeDetailTemplate = document.querySelector('#place-detail-template')
const commentTemplate = document.querySelector('#comment-template')
const placeFormTemplate = document.querySelector('#place-form-template')

let placeTypes = []

async function getTypes() {
    const res = await fetch('/type')
    placeTypes = await res.json()
}

async function getCities() {
    const res = await fetch('/city')
    const cities = await res.json()

    cities.forEach(c => {
        const clone = cityTemplate.content.cloneNode(true)

        const div = clone.querySelector('.city')
        const img = clone.querySelector('img')
        const p = clone.querySelector('.city-name')

        img.src = c.image_path
        p.textContent = c.name

        div.addEventListener('click', () => {
            getPlaces(c.id, c.name)
        })

        citiesContainer.appendChild(clone)
    })
}

async function getPlaces(cityId, cityName) {
    placesContainer.innerHTML = ''

    const heading = document.createElement('h2')
    heading.textContent = cityName
    placesContainer.appendChild(heading)

    const placesList = document.createElement('div')
    placesList.className = 'places-list'
    placesContainer.appendChild(placesList)

    const res = await fetch(`/city/${cityId}/places`)
    const places = await res.json()

    places.forEach(p => {
        const clone = placeTemplate.content.cloneNode(true)

        const img = clone.querySelector('img')
        const placeName = clone.querySelector('.place-name')
        const placeType = clone.querySelector('.place-type')
        const btnEdit = clone.querySelector('.btn-edit-place')
        const btnDelete = clone.querySelector('.btn-delete-place')

        img.src = p.image_path
        placeName.textContent = p.place_name
        placeType.textContent = p.type_name

        img.addEventListener('click', () => {
            getPlaceDetail(p.place_id)
        })
        placeName.addEventListener('click', () => {
            getPlaceDetail(p.place_id)
        })

        btnDelete.addEventListener('click', async () => {
            await fetch(`/place/${p.place_id}`, {
                method: 'DELETE'
            })

            await getPlaces(cityId, cityName)
        })

        btnEdit.addEventListener('click', () => {
            openEditForm(p, cityId, cityName)
        })

        placesList.appendChild(clone)
    })

    const formClone = placeFormTemplate.content.cloneNode(true)
    const form = formClone.querySelector('.new-place-form')
    const select = form.querySelector('.input-type')

    placeTypes.forEach(t => {
        const option = document.createElement('option')
        option.value = t.id
        option.textContent = t.name
        select.appendChild(option)
    })

    form.querySelector('.btn-save').addEventListener('click', async () => {
        const data = {
            cityId: cityId,
            typeId: form.querySelector('.input-type').value,
            name: form.querySelector('.input-place-name').value,
            description: form.querySelector('.input-desc').value,
            address: form.querySelector('.input-address').value,
            imagePath: form.querySelector('.input-image').value
        }

        await fetch('/place', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        await getPlaces(cityId, cityName)
    })

    placesContainer.appendChild(formClone)
}

async function openEditForm(place, cityId, cityName) {
    const existingForm = placesContainer.querySelector('.new-place-form.editing')
    if (existingForm) {
        existingForm.remove()
    }

    const res = await fetch(`/place/${place.place_id}`)
    const detail = await res.json()

    const formClone = placeFormTemplate.content.cloneNode(true)
    const form = formClone.querySelector('.new-place-form')
    form.classList.add('editing')

    form.querySelector('.form-title').textContent = `Upravit: ${place.place_name}`

    const select = form.querySelector('.input-type')
    placeTypes.forEach(t => {
        const option = document.createElement('option')
        option.value = t.id
        option.textContent = t.name
        select.appendChild(option)
    })

    form.querySelector('.input-type').value = detail.type_id
    form.querySelector('.input-place-name').value = detail.place_name
    form.querySelector('.input-desc').value = detail.place_description
    form.querySelector('.input-address').value = detail.place_address
    form.querySelector('.input-image').value = detail.image_path

    const btnCancel = form.querySelector('.btn-cancel')
    btnCancel.classList.remove('hidden')
    btnCancel.addEventListener('click', () => {
        form.remove()
    })

    const btnSave = form.querySelector('.btn-save')
    btnSave.textContent = 'Uložit změny'
    btnSave.addEventListener('click', async () => {
        const data = {
            cityId: cityId,
            typeId: form.querySelector('.input-type').value,
            name: form.querySelector('.input-place-name').value,
            description: form.querySelector('.input-desc').value,
            address: form.querySelector('.input-address').value,
            imagePath: form.querySelector('.input-image').value
        }

        await fetch(`/place/${place.place_id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        await getPlaces(cityId, cityName)
    })

    const staticForm = placesContainer.querySelector('.new-place-form:not(.editing)')
    placesContainer.insertBefore(form, staticForm)
}

async function getPlaceDetail(id) {
    const resPlace = await fetch(`/place/${id}`)
    const place = await resPlace.json()

    const resAverageRating = await fetch(`/place/${id}/average-rating`)
    const averageRating = await resAverageRating.json()

    const resComments = await fetch(`/place/${id}/comment`)
    const comments = await resComments.json()

    const clone = placeDetailTemplate.content.cloneNode(true)

    clone.querySelector('img').src = place.image_path
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

        let date = new Date(c.rating_date)

        divComment.querySelector('.person-name').textContent = c.rating_author
        divComment.querySelector('.person-date').textContent = date.toLocaleString('cs-CZ')
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

    const inputName = clone.querySelector('.input-name')
    const inputText = clone.querySelector('.input-text')
    const btnSend = clone.querySelector('.btn-send')

    btnSend.addEventListener('click', async () => {
        const data = {
            author: inputName.value,
            comment: inputText.value
        }

        const response = await fetch(`/review/place/comment/${id}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(data)
        })

        if (response.ok) {
            document.body.querySelector('.place-detail').remove()
            await getPlaceDetail(id)
        }
    })

    document.body.appendChild(clone)
}

getTypes()
getCities()