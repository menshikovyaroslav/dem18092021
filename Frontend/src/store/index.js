import Vue from 'vue'
import Vuex from 'vuex'
import Api from '@api/index'
// import bus from '@/utils/bus.plugin'

Vue.use(Vuex)

export default new Vuex.Store({
	state: {
		isAppReady: false,
		regionsList: [],
		portalsList: [],
		jobsList: [],
		casesList: []
	},

	mutations: {
		SET_STATE(state, { key, value }) {
			state[key] = value
		}
	},

	actions: {
		async initiateApp({ commit }) {
			try {
				const stateKeysList = ['regionsList', 'portalsList']
				const list = [Api.getRegionsList(), Api.getPortalsList()]

				const responses = await Promise.all(list)
				responses.forEach((res, index) =>
					commit('SET_STATE', {
						key: stateKeysList[index],
						value: res
					})
				)
			} catch (e) {
				console.error(e)
				this._vm.$snackbar({
					type: 'error',
					message:
						'Не удалось инициализировать приложение. Обратитесь в тех. поддержку.'
				})
			} finally {
				commit('SET_STATE', { key: 'isAppReady', value: true })
			}
		},

		async getJobsList({ state, commit }) {
			const parseDate = date =>
				new Date(date).toLocaleString('ru-RU', {
					year: 'numeric',
					month: 'long',
					day: 'numeric'
				})
			try {
				const jobsList = await Api.getJobsList()

				const parsedJobsList = jobsList.map(item => ({
					...item,
					dateCreated: parseDate(item.time),
					dateStart: parseDate(item.timeFrom),
					dateEnd: parseDate(item.timeTo),
					statusLabel: item.resultCode ? 'Завершено' : 'В очереди',
					portalName: state.portalsList.find(
						portalItem => portalItem.id === item.portalId
					).name
				}))

				commit('SET_STATE', { key: 'jobsList', value: parsedJobsList })
			} catch (e) {
				console.error(e)
				this._vm.$snackbar({
					type: 'error',
					message: 'Не удалось получить данные о задачах.'
				})
			}
		},

		async createNewJob({ dispatch }, { selectedPortal, selectedDate }) {
			try {
				const id = Date.now().toString()
				const portalId = selectedPortal.id
				const [timeFrom, timeTo] = selectedDate.map(date =>
					new Date(date).toISOString()
				)
				const res = await Api.createJob({
					id,
					portalId,
					timeFrom,
					timeTo
				})
				if (res.success) {
					dispatch('getJobsList')
					this._vm.$snackbar({
						type: 'success',
						message: 'Задача успешно создана.'
					})
				}
				return res
			} catch (e) {
				this._vm.$snackbar({
					type: 'error',
					message:
						'Не удалось создать новую задачу. Повторите попытку или обратитесь в тех. поддержку.'
				})
				console.error(e)
			}
		},

		async searchCases({ commit }, data) {
			try {
				const parsedData = {
					region: data.region ? data.region.id : null,
					number: data.caseNumber,
					dateFrom: data.date
						? new Date(data.date[0]).toISOString()
						: null,
					dateTo:
						data.date && data.date[1]
							? new Date(data.date[1]).toISOString()
							: null,
					sud: data.court,
					clause: data.clause,
					instance: data.instance,
					fio: data.fio,
					judge: data.judge
				}

				const fullFilterData = Object.fromEntries(
					Object.entries(parsedData).filter(([, v]) => v != null)
				)

				const casesList = await Api.getCasesList(fullFilterData)
				commit('SET_STATE', { key: 'casesList', value: casesList })
			} catch (e) {
				this._vm.$snackbar({
					type: 'error',
					message: 'Не удалось получить данные о делах.'
				})
				console.error(e)
			}
		}
	}
})
