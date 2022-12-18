<script>
	import { TextField, Button, Headline, Label, Modal, Dialog } from 'attractions'
	import { fade } from 'svelte/transition';
	import { onMount } from 'svelte';

	let signIn = true;
	let secondaryByttonText = 'Sign in'
	let inited = false

	let loginUserName = '';
	let loginPassword = '';

	let registrationFirstPassword = '';
	let registrationSecondPassword = '';
	let registrationUsername = '';
	let registrationEmail = '';

	let openModalWindow = false;
	let reasonOfModalWindow = '';
	let messageOfModalWindow = '';

	onMount(() => {
		setTimeout(() => {
			inited = true
		}, 500)
	})

	function submit() {
		if (signIn) {
			if (loginUserName === '') {
				ShowModalWindow('Empty field', 'Please type the username')
				return;
			}
			else if (loginPassword === '') {
				ShowModalWindow('Empty field', 'Please type the password')
				return;
			}
		}
		else {
			if (registrationUsername === '') {
				ShowModalWindow('Empty field', 'Please type the username')
				return;
			}
			else if (registrationEmail === '') {
				ShowModalWindow('Empty field', 'Please type the email')
				return;
			}
			else if (!emailIsValid(registrationEmail)) {
				ShowModalWindow('Invalid email field value', 'Please type currect email address')
				return;
			}
			else if (registrationFirstPassword === '' || registrationSecondPassword === '') {
				ShowModalWindow('Empty field', 'Please type the password')
				return;
			}
			else if (registrationFirstPassword !== registrationSecondPassword) {
				ShowModalWindow('Invalid password field value', 'The passwords must be the same')
				return;
			}
		}
	}

	function ShowModalWindow(reason, message) {
		openModalWindow = true;
		reasonOfModalWindow = reason;
		messageOfModalWindow = message;
	}

	function emailIsValid(registrationEmail) {
	  return registrationEmail.match(
	    /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
	  );
	};

	function switchSignMode() {
		secondaryByttonText = signIn ? "Sign in" : "Sign up";
		signIn = !signIn;
	}
</script>

<main>

	<div class="container">
		<div class="left-side">
			<div class="left-side-container">
				<Headline>Welcome</Headline>
				<form on:submit|preventDefault={submit}>
					{#if signIn}
						<p>Log in to your account</p>
						<TextField bind:value={loginUserName} autofocus outline label="Username"/>
						<TextField bind:value={loginPassword} type="password" outline label="Password"/>
					{:else}
						<p>Create an account</p>
						<TextField bind:value={registrationUsername} outline label="Username"/>
						<TextField error={registrationEmail != '' && !emailIsValid(registrationEmail) && 'Invalid email'} bind:value={registrationEmail} outline label="Email"/>
						<TextField error={registrationFirstPassword != registrationSecondPassword && 'The passwords must be the same'} bind:value={registrationFirstPassword} type="password" outline label="Password"/>
						<TextField error={registrationFirstPassword != registrationSecondPassword && 'The passwords must be the same'} bind:value={registrationSecondPassword} type="password" outline label="Confirm Password"/>
					{/if}
					<div class="buttons">
						<Button type="submit" filled>Submit</Button>
						<Button on:click={switchSignMode} outline>{secondaryByttonText}</Button>
					</div>
				</form>
			</div>
		</div>
		<div class="right-side">
			{#if inited}
			<div class="right-side-container">
				<img transition:fade="{{duration: 1500}}" class="parallax" src="mascot.svg"/>
				<div transition:fade="{{deladuration: 1500, delay: 500}}">
					<Headline>xClient</Headline>
					<Label small>Multiple connections in one place</Label>	
				</div>	
			</div>
			{/if}
		</div>
	</div>
	<Modal noClickaway bind:open={openModalWindow} let:closeCallback>
		<Dialog title={reasonOfModalWindow} {closeCallback}>
		  {messageOfModalWindow}
		</Dialog>
	</Modal>
</main>

<style>
    main {
		padding: 20px;
		background: linear-gradient(45deg, #4300B0, #F0F8FF);
	}

	form {
		display: grid;
		gap: 20px;
	}

	img {
		width: 100%;
	}

	p {
		font-size: 20px;
	}

	.container {
		min-height: calc(100vh - 20px * 2);
		display: grid;
		grid-template-columns: 50% 50%;
		border-radius: 20px;
		overflow: hidden;
		box-shadow: 5px 5px 10px grey;
	}

	.left-side {
		background-color: white;
		display: flex;
		justify-content: center;
	}

	.left-side-container {
		padding: 17% 20%;
		width: 60%;
	}

	.right-side {
		display: flex;
		justify-content: center;
		background-color: aliceblue;
	}

	.right-side-container {
		text-align: center;
		padding-top: 10%;
		height: 40%;
		width: 40%;
		display: grid;
		font-size: 30px;
	}

	.buttons {
		display: grid;
		grid-template-columns: 45% 45%;
		grid-column-gap: 10%;
	}
</style>