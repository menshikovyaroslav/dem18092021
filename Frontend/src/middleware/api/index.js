import axios from "axios"

const baseURL = "http://94.180.116.89:5522/"

export default {
	getRegionsList() {
		return axios.get(`${baseURL}/api/regions`).then(r => r.data);
	},

	getPortalsList() {
		return axios.get(`${baseURL}/api/portals`).then(r => r.data);
	},

    createJob(jobData) {
		return axios.post(`${baseURL}/api/portals`, jobData).then(r => r.data);
	},

    getJobsList() {
		return axios.get(`${baseURL}/jobs`).then(r => r.data);
	},

    getJobById(jobId) {
		return axios.get(`${baseURL}/jobs/${jobId}`).then(r => r.data);
	},
    
    getInfoByParams(data) {
        return axios.post(`${baseURL}/api/getbyparameters`, data).then(r => r.data);
    }

};