<template>
  <v-container>
    <v-row class="text-center">
      <v-col
        cols="4"
        class="mt-4"
      >
        <v-select
          v-model="chosenData.region"
          :items="regionList"
          label="Регион"
          item-text="name"
          return-object
          dense
        />
      </v-col>
      <v-col
        cols="4"
        class="mt-4"
      >

      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import axios from 'axios'

export default {
  name: 'Home',
  data() {
    return {
      chosenData: {
        region: {
          name: '',
          id: 0,
        },
        portal: {
          name: '',
          id: 0,
          link: '',
        },
      },
      regionList: [],
      portalList: [],
    }
  },
  methods: {},
  mounted() {
    axios({
      url: 'http://94.180.116.89:5522/api/regions',
      method: 'get',
    })
      .then(res => this.regionList = res.data)
      .catch(error => console.log(`error`, error))
    axios({
      url: 'http://94.180.116.89:5522/api/portals',
      method: 'get',
    })
      .then(res => this.portalList = res.data)
      .catch(error => console.log(`error`, error))
  },
}
</script>
