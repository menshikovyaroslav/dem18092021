import Vue from 'vue'
import Snackbar from 'node-snackbar'
const snackbar = Snackbar

Vue.use({
	install: V => {
		V.prototype.$snackbar = opts => {
			const options = {
				text: opts.message,
				textColor: opts.textColor,
				pos: opts.position ?? 'top-center',
				customClass: opts.type ?? 'info',
				width: opts.width,
				showAction: !!opts.event,
				actionText: opts.event,
				actionTextAria: opts.event ?? 'Закрыть',
				alertScreenReader: true,
				actionTextColor: opts.eventTextColor,
				backgroundColor: opts.backgroudColor,
				duration: opts.duration ?? 6000,
				onActionClick: opts.action,
				onClose: opts.onCloseEvent
			}

			snackbar.show(options)

			return snackbar
		}
	}
})

export default Snackbar
