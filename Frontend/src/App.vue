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
<style lang="scss">
	.v-sheet.v-card:not(.v-sheet--outlined) {
		border-radius: 10px;
	}
	.snackbar {
		&-container {
			transition: all 500ms ease;
			transition-property: top, right, bottom, left, opacity;
			position: fixed;
			justify-content: space-between;
			align-items: center;
			text-align: center;
			line-height: 22px;
			bottom: -100px;
			top: -100px;
			opacity: 0;
			z-index: 500;
			display: inline-flex;
			margin: 24px 0;
			max-width: calc(100% - 50px);

			min-height: 49px;
			background: #424242;
			border-radius: 4px;
			color: #fff;
			box-sizing: border-box;
			padding: 10px 24px;
			font-size: 14px;
			box-shadow: 0px 6px 10px rgba(0, 0, 0, 0.14),
				0px 1px 18px rgba(0, 0, 0, 0.12), 0px 3px 5px rgba(0, 0, 0, 0.2);

			&.success {
				background-color: green;
			}

			&.error {
				background-color: red;
			}
		}

		&-pos {
			bottom: auto !important;
			top: 0;
			left: 50%;
			transform: translate(-50%, 0);

			&.bottom-center {
				top: auto !important;
				bottom: 0;
			}
		}
	}
</style>
