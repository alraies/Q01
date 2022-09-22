<template>
  <div class="container">
        <p>
          <rate :length="5" :ratedesc="desc" />
        </p>
  </div>
</template>

<script>
import rate from '../src/Rate'

export default {
  name: 'App',
  data () {
    return {
      myCurrentRate: 3,
      desc: ['Very Bad', 'Bad', 'Normal', 'Good', 'Very Good']
    }
  },
  components: {
    rate
  }
}
</script>

<style>

#app {
  text-align: center;
  color: #2c3e50;
  margin-top: 60px
}
.container {
  max-width: 1200px;
  padding: 0 20px;
  margin: 0 auto
}
</style>

