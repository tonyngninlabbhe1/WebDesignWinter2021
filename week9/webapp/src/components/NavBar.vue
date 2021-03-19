<template>
    <div class="links">
        <span v-if="$auth.isAuthenticated" @click='goToHome'>Home</span>
        <span v-if="$auth.isAuthenticated" @click='goToTables'>Student</span>
        <span v-if="$auth.isAuthenticated" @click='goToForms'>Instrutor</span>
        <span v-if="$auth.isAuthenticated" @click='goToProfilePage'>Profile</span>
        <span v-if="$auth.isAuthenticated" @click='goToExternalAPI'>External Api</span>
         <!-- Check that the SDK client is not currently loading before accessing is methods -->
    <div v-if="!$auth.loading">
      <!-- show login when not authenticated -->
      <button v-if="!$auth.isAuthenticated" @click="login">Log in</button>
      <!-- show logout when authenticated -->
      <button v-if="$auth.isAuthenticated" @click="logout">Log out</button>
    </div>
    </div>
</template>

<script>
  export default {
    name: 'NavBar',
    methods: {
      goToHome: function() {
        this.$router.push({ path: 'home' })
      },
      goToTables: function() {
        this.$router.push({ path: 'students' })
      },
      goToForms: function() {
        this.$router.push({ path: 'instrutors' })
      },
      goToProfilePage: function() {
        this.$router.push({ path: 'profile' })
      },
      goToExternalAPI: function() {
        this.$router.push({ path: 'external-api' })
      },
      // Log the user in
      login() {
        this.$auth.loginWithRedirect();
      },
      // Log the user out
      logout() {
        this.$auth.logout({
          returnTo: window.location.origin
        });
    }

    }
  }
</script>

<style scoped>
  span {
      font-family: monospace;
      font-weight: bold;
      font-size: 14pt;
      cursor: pointer;
      padding-right: 20px;
      color: rgb(13, 34, 224);
      background-color: white;
      text-align: center;
  }

  .links {
      background-color: lightgray;
      margin-top: 20px;
      padding: 10px;
  }
</style>