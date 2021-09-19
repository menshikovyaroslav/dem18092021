<template>
	<v-container fluid>
		<v-fade-transition>
			<spinner-loader v-if="!isAppReady" />

			<v-row v-else class="text-center">
				<v-col class="mt-4 col-12 col-md-3">
					<job-form />
				</v-col>

				<v-col class="mt-4 col-12 col-md-9">
					<v-row>
						<top-list />
					</v-row>
					<v-row class="d-flex justify-center mt-6">
						<jobs-table />
					</v-row>
				</v-col>

				<v-col class="col-12">
					<v-divider class="home__divider"></v-divider>
					<cases-table />
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
	import TopList from "@components/TopList.vue";
	import CasesTable from "@components/CasesTable.vue";

	export default {
		name: "MainPage",
		components: {
			SpinnerLoader,
			JobForm,
			JobsTable,
			TopList,
			CasesTable,
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
	.home {
		&__divider {
			margin-top: 30px;
		}
	}
</style>
