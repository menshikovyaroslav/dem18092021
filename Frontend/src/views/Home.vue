<template>
  <v-container>
    <v-row class="text-center">

    </v-row>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Home',
  data() {
    return {}
  },
  methods: {},
  mounted() {
    axios({
      method: 'post',
      url: 'http://94.180.116.89:5522/api/getbynumber',
      data: {
        number: '',
        region: 777,
      },
    })
      .then(res => {
        console.log(`res`, res)
      })
      .catch(err => {
        console.log(`error`, err)
      })
  },
}
</script>
