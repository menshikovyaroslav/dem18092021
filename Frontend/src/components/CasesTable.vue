<template>
	<v-row class="cases-table">
		<v-col class="cases-table__filter col-12 col-md-3">
			<h2 class="mb-3">Фильтр дел</h2>
			<v-select
				v-model="filter.region"
				:items="regionsList"
				label="Регион"
				item-text="name"
				dense
				outlined
				return-object
			/>
			<v-select
				v-model="filter.caseNumber"
				:items="caseNumbersList"
				label="Номер дела"
				dense
				outlined
				return-object
			/>

			<v-menu
				v-model="showDateMenu"
				:close-on-content-click="false"
				:nudge-right="40"
				transition="scale-transition"
				offset-y
				min-width="auto"
			>
				<template v-slot:activator="{ on, attrs }">
					<v-text-field
						v-model="formattedDate"
						label="Диапазон дат"
						prepend-icon="mdi-calendar"
						readonly
						dense
						outlined
						v-bind="attrs"
						v-on="on"
					></v-text-field>
				</template>
				<v-date-picker v-model="filter.date" range></v-date-picker>
			</v-menu>

			<v-text-field
				label="Суд"
				v-model="filter.court"
				dense
				outlined
			></v-text-field>

			<v-text-field
				label="Подразделение"
				v-model="filter.clause"
				dense
				outlined
			></v-text-field>

			<v-text-field
				label="Инстанция"
				v-model="filter.instance"
				dense
				outlined
			></v-text-field>

			<v-text-field
				label="ФИО подсудимого"
				v-model="filter.fio"
				dense
				outlined
			></v-text-field>

			<v-text-field
				label="ФИО судьи"
				v-model="filter.judge"
				dense
				outlined
			></v-text-field>

			<v-btn
				tile
				text
				color="primary"
				@click="clearFilter"
				:disabled="!isFilterClearable"
				>Очистить фильтр</v-btn
			>
		</v-col>
		<v-col class="col-12 col-md-9">
			<div class="cases-table__table">
				<h2>Список дел</h2>
				<v-data-table
					@click:row="handleRowClick"
					hide-default-footer
					:loading="loadingList"
					loading-text="Загружаются данные о делах..."
					:headers="headers"
					:items="casesList"
					:items-per-page="Infinity"
					:item-class="() => 'cases-table__row'"
					locale="ru-RU"
				>
				</v-data-table>
			</div>
		</v-col>
	</v-row>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	import { formatDate, debounce } from "@utils/";
	export default {
		name: "CasesTable",
		data: () => ({
			loadingList: true,
			caseNumbersList: ["137", "138", "272", "274"],
			showDateMenu: false,
			filter: {
				region: null,
				caseNumber: null,
				date: null,
				court: null,
				clause: null,
				instance: null,
				fio: null,
				judge: null,
			},
			headers: [
				{
					text: "Номер дела",
					value: "number",
					sortable: true,
				},
				{
					text: "Регион",
					sortable: true,
					value: "regionName",
				},
				{ text: "От", value: "dateStart", sortable: true },
				{ text: "До", value: "dateEnd", sortable: true },
				{ text: "Суд", value: "courtName", sortable: true },
				{ text: "Подразделение", value: "clause", sortable: true },
				{ text: "Инстанция", value: "instance", sortable: true },
				{ text: "ФИО подсудимого", value: "fio", sortable: true },
				{ text: "ФИО судьи", value: "judge", sortable: true },
			],
		}),
		watch: {
			filter: {
				deep: true,
				handler: function () {
					console.log(this);
					this.searchCasesDebounced();
				},
			},
		},

		computed: {
			...mapState(["casesList", "regionsList"]),

			formattedDate() {
				if (!this.selectedDate) return "";
				return this.selectedDate
					.map((date) => formatDate(date))
					.join(" - ");
			},

			isFilterClearable() {
				return Object.values(this.filter).some((val) => val !== null);
			},

			searchCasesDebounced() {
				return debounce(this.searchFilteredCases, 1000);
			},
		},
		methods: {
			...mapActions(["searchCases"]),

			handleRowClick() {
				console.log("table row clicked");
			},

			searchFilteredCases() {
				console.log("search");
				this.searchCases(this.filter);
			},
			clearFilter() {
				this.filter = {
					region: null,
					caseNumber: null,
					date: null,
					court: null,
					clause: null,
					instance: null,
					fio: null,
					judge: null,
				};
			},
		},
		async created() {
			try {
				await this.searchCases({});
			} finally {
				this.loadingList = false;
			}
		},
	};
</script>

<style scoped lang="scss">
	.cases-table {
		padding-top: 30px;
	}
</style>