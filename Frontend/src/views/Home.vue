<template>
	<v-container fluid>
		<v-fade-transition>
			<spinner-loader v-if="!isAppReady" />

			<v-row v-else class="text-center">
				<v-col cols="4" class="mt-4"> </v-col>
				<v-col cols="4" class="mt-4"> </v-col>
			</v-row>
		</v-fade-transition>
	</v-container>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	import SpinnerLoader from "@components/SpinnerLoader.vue";

	export default {
		name: "MainPage",
		components: {
			SpinnerLoader,
		},
		computed: {
			...mapState(["regionsList", "portalsList", "isAppReady"]),
		},
		methods: {
			...mapActions(["initiateApp"]),
		},
		created() {
			this.initiateApp();
		},
	};
</script>

<style scoped lang="scss">
</style>
