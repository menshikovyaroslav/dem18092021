import Vue from 'vue'
import Vuex from 'vuex'
import Api from '@api/index';
// import bus from '@/utils/bus.plugin'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    isAppReady: false,
    regionsList: [],
    portalsList:[]
  },
  mutations: {
    SET_STATE(state, { key, value }) {
      state[key] = value;
    },
  
  },
  actions: {
    async initiateApp({commit, dispatch}){
      try {
        const responses = await dispatch("getPortalsList")
        if(responses) {
          commit('SET_STATE', {key: 'isAppReady', value: true})
        }
      } catch(e) {
        console.warn(e)
      }
    },

   async  getPortalsList({commit}) {
      try {
        const stateKeysList = ["regionsList", "portalsList"]
        const list = [Api.getRegionsList(), Api.getPortalsList()]

        const responses = await Promise.all(list);
          responses.forEach((res, index) =>
            commit('SET_STATE', {
              key: stateKeysList[index],
              value: res,
            }),
          );
          return responses
      } catch(e) {
        console.warn(e)
      }
    }
  },
  modules: {
  }
})
