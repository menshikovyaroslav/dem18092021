<template>
	<v-form>
		<v-select
			v-model="chosenData.region"
			:items="regionList"
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
	export default { name: "JobForm" };
</script>

<style lang="scss" scoped>
</style>