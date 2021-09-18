export default {
  install(Vue) {
    Vue.prototype.$throttle = (fn, limit) => {
      let throttling = false
      return (...args) => {
        if (!throttling) {
          throttling = true
          setTimeout(() => throttling = false, limit)
          return fn(...args)
        }
      }
    }
  }
}