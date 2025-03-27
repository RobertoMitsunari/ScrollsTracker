<template>
  <div class="manga-box">
    <img :src="imagem" alt="Capa do Mangá" class="manga-img">
    <h2 class="manga-title">{{ titulo }}</h2>
  </div>
</template>

<script setup>
defineProps({
  titulo: String,
  imagem: String
});
</script>

<style scoped>
.manga-box {
  margin-top: 20px;
  padding: 15px;
  border: 1px solid #444;
  border-radius: 10px;
  background-color: #1c1f26;
  text-align: center;
  width: 300px;
}

.manga-img {
  width: 100%;
  height: auto;
  border-radius: 5px;
}

.manga-title {
  margin-top: 10px;
  font-size: 18px;
}
</style>
