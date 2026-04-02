const citiesContainer = document.querySelector('.cities')
const placesContainer = document.querySelector('.city-detail')
const cityTemplate = document.querySelector('#city-template');
const placeTemplate = document.querySelector('#place-template');

async function getCities(){
    const res = await fetch('/city')
    const cities = await res.json()

    cities.forEach(c => {
        const clone = cityTemplate.content.cloneNode(true);

        const div = clone.querySelector('.city');
        const img = clone.querySelector('img');
        const p = clone.querySelector('.city-name');

        div.dataset.cityId = c.id;
        img.src = c.image_path;
        p.textContent = c.name;

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

        const img = clone.querySelector('img')
        const placeName = clone.querySelector('.place-name')
        const placeType = clone.querySelector('.place-type')

        img.src = 'https://placehold.co/600x400'
        placeName.textContent = p.place_name
        placeType.textContent = p.type_name

        placesContainer.appendChild(clone)
    })
}

getCities()