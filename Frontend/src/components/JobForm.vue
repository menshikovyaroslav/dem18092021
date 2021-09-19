<template>
	<v-card class="pl-4 pr-4 pt-4 pb-3">
		<v-form ref="form">
			<v-select
				v-model="selectedPortal"
				:items="portalsList"
				label="Портал"
				item-text="name"
				dense
				outlined
				:rules="rules.selectedPortal"
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

			<v-btn
				color="primary"
				:disabled="formLoading"
				:loading="formLoading"
				@click="applyForm"
				>Создать заявку</v-btn
			>
		</v-form>
	</v-card>
</template>

<script>
	import { mapState, mapActions } from "vuex";
	import { formatDate } from "@utils/";
	export default {
		name: "JobForm",
		data: () => ({
			selectedRegion: null,
			selectedPortal: null,
			selectedDate: null,
			showDateMenu: false,
			formLoading: false,

			rules: {
				selectedPortal: [(v) => !!v || "Необходимо выбрать портал."],
			},
		}),
		computed: {
			...mapState(["regionsList", "portalsList"]),
			formattedDate() {
				if (!this.selectedDate) return "";
				return this.selectedDate
					.map((date) => formatDate(date))
					.join(" - ");
			},
		},
		methods: {
			...mapActions(["createNewJob"]),

			async applyForm() {
				try {
					this.formLoading = true;
					const isFormValid = this.$refs.form.validate();
					if (!isFormValid) {
						return;
					}

					this.createNewJob({
						selectedPortal: this.selectedPortal,
						selectedDate: this.selectedDate,
					});
				} finally {
					this.formLoading = false;
				}
			},
		},
	};
</script>

<style lang="scss" scoped>
</style>