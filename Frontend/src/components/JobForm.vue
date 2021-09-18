<template>
	<v-form>
		<v-select
			v-model="chosenData.region"
			:items="regionsList"
			label="Регион"
			item-text="name"
			return-object
			dense
		/>
		<v-select
			v-model="chosenData.portal"
			:items="portalList"
			label="Портал"
			item-text="name"
			return-object
			dense
		/>
	</v-form>
</template>

<script>
	import { mapState } from "vuex";
	export default {
		name: "JobForm",
		computed: {
			...mapState(["regionsList", "portalsList"]),
		},
	};
</script>

<style lang="scss" scoped>
</style>