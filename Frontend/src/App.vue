<template>
	<v-app>
		<v-app-bar app color="primary" dark>
			<v-spacer></v-spacer>
			<div class="d-flex text-center">
				<h2>Инфографика судебной информации</h2>
			</div>
			<v-spacer></v-spacer>
		</v-app-bar>

		<v-main>
			<router-view />
		</v-main>
	</v-app>
</template>

<script>
	export default {
		name: "App",
	};
</script>
