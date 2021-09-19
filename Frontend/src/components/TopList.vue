<template>
	<v-col class="col-12 d-flex toplist">
		<v-card class="toplist__item" v-for="list in topsList" :key="list.name">
			<v-card-title class="justify-center">{{ list.name }}</v-card-title>
			<v-card-subtitle class="toplist__list">
				<div v-for="(value, index) in list.list" :key="index">
					{{ `${index + 1}: ${value}` }}
				</div>
			</v-card-subtitle>
		</v-card>
	</v-col>
</template>

<script>
	export default {
		name: "TopList",
		data: () => ({
			topsList: [
				{
					name: "Топ судов",
					list: [
						"Пресненский",
						"Замоскворецкий",
						"Басманный",
						"Мещанский",
						"Хорошёвский",
					],
				},
				{
					name: "Топ городов",
					list: [
						"Москва",
						"Ярославль",
						"Хабаровск",
						"Иваново",
						"Королев",
					],
				},
				{
					name: "Топ по типам",
					list: ["ФИО", "Адрес", "Год рождения"],
				},
			],
		}),
	};
</script>

<style lang="scss" scoped>
	.toplist {
		justify-content: space-between;
		flex-direction: column;

		@media screen and (min-width: 960px) {
			flex-direction: row;
		}

		&__item {
			&:not(:first-child) {
				margin-top: 20px;
			}
			@media screen and (min-width: 960px) {
				width: 30%;

				&:not(:first-child) {
					margin-top: 0;
				}
			}
		}

		&__list {
			margin-top: 10px;
		}
	}
</style>