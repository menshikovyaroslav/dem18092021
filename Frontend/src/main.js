import Vue from 'vue'
import App from './App.vue'

import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import bus from './utils/bus.plugin'

//  Plagins
import delayPlagin from './utils/delay.plugin'
import throttlePlagin from './utils/throttle.plugin'

Vue.use(delayPlagin)
Vue.use(throttlePlagin)

Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  bus,
  render: h => h(App)
}).$mount('#app')
