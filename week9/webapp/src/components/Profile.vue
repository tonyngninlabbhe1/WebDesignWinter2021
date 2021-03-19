<template>
  <div>
    <div>
      <img :src="this.$auth.user.picture">
      <h2>{{ this.$auth.user.name }}</h2>
      <p>{{ this.$auth.user.email }}</p>
    </div>

    <div>
      <pre>{{ JSON.stringify(this.$auth.user, null, 2) }}</pre>
    </div>
  </div>
</template>