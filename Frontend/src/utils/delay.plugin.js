export default {
  install(Vue) {
    Vue.prototype.$delay = ms => new Promise(r => setTimeout(r, ms))
  }
}