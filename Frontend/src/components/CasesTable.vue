<template>
	<div class="cases-table">
		<div class="cases-table__table">
			<h2>Список дел</h2>
			<v-data-table
				@click:row="handleRowClick"
				hide-default-footer
				:loading="loadingList"
				loading-text="Загружаются данные о запросах..."
				:headers="headers"
				:items="jobsList"
				:items-per-page="Infinity"
				:item-class="() => 'jobs-table__row'"
				locale="ru-RU"
			>
			</v-data-table>
		</div>
	</div>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	export default {
		name: "CasesTable",
		data: () => ({
			loadingList: true,
			headers: [
				{
					text: "Портал",
					value: "portalName",
					sortable: true,
				},
				{
					text: "Дата создания",
					sortable: true,
					value: "dateCreated",
				},
				{ text: "От", value: "dateStart", sortable: true },
				{ text: "До", value: "dateEnd", sortable: true },
				{ text: "Статус", value: "statusLabel", sortable: true },
			],
		}),
		computed: {
			...mapState(["jobsList"]),
		},
		methods: {
			...mapActions(["getJobsList"]),

			handleRowClick() {
				console.log("table row clicked");
			},
		},
		async created() {
			try {
				await this.getJobsList();
			} finally {
				this.loadingList = false;
			}
		},
	};
</script>

<style scoped lang="scss">
	.jobs-table {
		display: flex;
		flex-direction: column;
		align-items: center;
	}
</style>