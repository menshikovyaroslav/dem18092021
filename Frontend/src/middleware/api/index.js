import axios from "axios"

const baseURL = "http://94.180.116.89:5522/"

export default {
	getRegionsList() {
		return axios.get(`${baseURL}/api/regions`).then(r => r.data);
	},

	getPortalsList() {
		return axios.get(`${baseURL}/api/portals`).then(r => r.data);
	},

};