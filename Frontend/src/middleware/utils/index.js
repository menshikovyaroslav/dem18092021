export function debounce(f, ms) {
	let isCooldown = false

	return function() {
		if (isCooldown) return

		f.apply(this, arguments)

		isCooldown = true

		setTimeout(() => (isCooldown = false), ms)
	}
}

export function formatDate(date) {
	const [year, month, day] = date.split('-')
	return `${day}.${month}.${year}`
}
