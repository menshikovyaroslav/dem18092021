<template>
	<v-row class="cases-table">
		<v-col class="cases-table__filter col-12 col-md-3">
			<v-card class="pl-4 pr-4 pt-4">
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
					label="Номер статьи"
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
			</v-card>
		</v-col>
		<v-col class="col-12 col-md-9">
			<v-card class="cases-table__table pt-4">
				<div class="d-flex">
					<h2 class="mx-auto">Список дел</h2>

					<v-btn
						@click="downloadExcel"
						class="mr-4"
					>Выгрузить</v-btn>
				</div>

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
			</v-card>
		</v-col>
	</v-row>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	import { formatDate, debounce } from "@utils/";
	import excelConvertMixin from '@/mixins/excel-convert.mixin'

	export default {
		name: "CasesTable",
		mixins: [excelConvertMixin],
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
				{ text: "Решение", value: "desition", sortable: true },
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

			downloadExcel() {
				if (!this.casesList.length)
					return

				const filenameStr = `Список дел`,
							newKeys = this.headers.reduce((obj, el) => Object.assign(obj, {[el.value]: el.text}), {}),
							json = this.convertJsonData(this.casesList, newKeys),
							workbook = this.convertToXLSX(json, filenameStr)

				this.downloadCreatedFile({workbook, filenameStr})
			},

			handleRowClick() {
				console.log("table row clicked");
			},

			async searchFilteredCases() {
				try {
					this.loadingList = true;
					await this.searchCases(this.filter);
				} finally {
					this.loadingList = false;
				}
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
				await this.searchCases({
					region: null,
					caseNumber: null,
					date: null,
					court: null,
					clause: null,
					instance: null,
					fio: null,
					judge: null,
				});
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