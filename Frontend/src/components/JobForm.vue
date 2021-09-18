<template>
	<v-form ref="form">
		<v-select
			v-model="selectedRegion"
			:items="regionsList"
			label="Регион"
			item-text="name"
			return-object
			dense
			outlined
			:rules="rules.selectedRegion"
		/>

		<v-select
			v-model="selectedPortal"
			:items="portalsList"
			label="Портал"
			item-text="name"
			return-object
			dense
			outlined
			:rules="rules.selectedPortal"
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
					label="Дата"
					prepend-icon="mdi-calendar"
					readonly
					dense
					outlined
					v-bind="attrs"
					v-on="on"
				></v-text-field>
			</template>
			<v-date-picker v-model="selectedDate" range></v-date-picker>
		</v-menu>

		<v-btn primary @click="applyForm">Создать заявку</v-btn>
	</v-form>
</template>

<script>
	import { mapState } from "vuex";
	export default {
		name: "JobForm",
		data: () => ({
			selectedRegion: null,
			selectedPortal: null,
			selectedDate: null,
			showDateMenu: false,

			rules: {
				selectedRegion: [(v) => v || "Необходимо выбрать регион."],
				selectedPortal: [(v) => v || "Необходимо выбрать портал."],
			},
		}),
		computed: {
			...mapState(["regionsList", "portalsList"]),
			formattedDate() {
				if (!this.selectedDate) return "";
				return this.selectedDate
					.map((date) => this.formatDate(date))
					.join(" - ");
			},
		},
		methods: {
			formatDate(date) {
				const [year, month, day] = date.split("-");
				return `${day}.${month}.${year}`;
			},

			applyForm() {
				const isFormValid = this.$refs.form.validate();
				if (!isFormValid) {
					return;
				}
				console.log("applied");
			},
		},
	};
</script>

<style lang="scss" scoped>
</style>