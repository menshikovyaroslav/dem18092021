import Vue from 'vue'
const { _events, $on, $once, $off, $emit } = new Vue()

const bus = { _events, on: $on, once: $once, off: $off, emit: $emit }

Vue.use({
  install(Vue) {
    Vue.prototype.$bus = bus
  }
})

export default bus