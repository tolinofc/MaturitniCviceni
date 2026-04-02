const cities = document.querySelector('.cities')
const places = document.querySelector('.city-detail')

async function getCities(){
    const res = await fetch('/city')
    const cities = await res.json()

    cities.forEach(c => {
        getCity(c)
    })
}

async function getPlaces(id) {
    const res = await fetch(`/city/${id}/places`)
    const places = await res.json()

    console.log(places)

    places.forEach(p => {
        getPlace(p)
    })
}

async function getCity(city) {
    let div = document.createElement('div')
    let img = document.createElement('img')
    let p = document.createElement('p')

    div.classList.add('city')
    div.dataset.cityId = city.id
    console.log(div)
    img.src = city.image_path
    p.textContent = city.name
    p.classList.add('city-name')

    div.appendChild(img)
    div.appendChild(p)

    div.addEventListener('click', () => {
        getPlaces(city.id)
    })

    cities.appendChild(div)
}

async function getPlace(place) {
    let div = document.createElement('div')
    let img = document.createElement('img')
    let placeName = document.createElement('p')
    let placeDescription = document.createElement('p')

    places.innerHTML = ''

    div.classList.add('place')

    img.src = 'images\\Ostrava.jpg'

    placeName.textContent = place.place_name
    placeName.classList.add('place-name')

    placeDescription.textContent = place.type_name
    placeDescription.classList.add('place-description')

    div.appendChild(img)
    div.appendChild(placeName)
    div.appendChild(placeDescription)

    places.appendChild(div)
}

getCities()