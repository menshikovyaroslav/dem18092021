<template>
	<v-container fluid>
		<v-fade-transition>
			<spinner-loader v-if="!isAppReady" />

			<v-row v-else class="text-center">
				<v-col class="mt-4 col-12 col-md-3">
					<job-form />
				</v-col>

				<v-col class="mt-4 col-12 col-md-9">
					<jobs-table />
				</v-col>
			</v-row>
		</v-fade-transition>
	</v-container>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	import SpinnerLoader from "@components/SpinnerLoader.vue";
	import JobForm from "@components/JobForm.vue";
	import JobsTable from "@components/JobsTable.vue";

	export default {
		name: "MainPage",
		components: {
			SpinnerLoader,
			JobForm,
			JobsTable,
		},
		computed: {
			...mapState(["isAppReady"]),
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
