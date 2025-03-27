<template>
  <div class="manga-chat">
    <nav class="navbar">
      <h1 class="logo">ScrollTracker</h1>
      <div class="search-box">
        <input v-model="titulo" placeholder="Digite o título do mangá" class="input">
        <button @click="buscarManga" class="button">Buscar</button>
      </div>
    </nav>

    <div v-if="mangaData" class="manga-box">
      <img :src="mangaData.imagem" alt="Capa do Mangá" class="manga-img">
      <h2 class="manga-title">{{ mangaData.titulo }}</h2>
    </div>

    <p v-if="erro" class="error-message">{{ erro }}</p>
  </div>
</template>

<script setup>
import { ref } from 'vue';

const titulo = ref('');
const mangaData = ref(null);
const erro = ref('');

const buscarManga = async () => {
  if (!titulo.value.trim()) {
    erro.value = 'Digite um título para buscar';
    mangaData.value = null;
    return;
  }

  try {
    erro.value = '';
    console.log(`🔍 Buscando mangá: ${titulo.value}`); 

    const response = await fetch(`https://localhost:7071/api/manga/buscar?titulo=${encodeURIComponent(titulo.value)}`);
    const data = await response.json();
    
    console.log("📥 Resposta do backend:", data); 

    if (!response.ok || Object.keys(data).length === 0) {
      throw new Error("Mangá não encontrado.");
    }

    mangaData.value = data;
  } catch (error) {
    console.error("❌ Erro ao buscar o mangá:", error);
    erro.value = "Erro ao buscar o mangá. Verifique o título.";
    mangaData.value = null;
  }
};

</script>

<style scoped>
.manga-chat {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 20px;
}

.navbar {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  padding: 10px 20px;
  background-color: #333;
  color: white;
}

.logo {
  font-size: 24px;
  font-weight: bold;
}

.search-box {
  display: flex;
  gap: 10px;
}

.input {
  padding: 8px;
  width: 200px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 14px;
}

.button {
  padding: 8px 12px;
  font-size: 14px;
  color: white;
  background-color: #007bff;
  border: none;
  border-radius: 5px;
  cursor: pointer;
}

.button:hover {
  background-color: #0056b3;
}

.manga-box {
  margin-top: 20px;
  padding: 15px;
  border: 1px solid #444;
  border-radius: 10px;
  background-color: #1c1f26;
  text-align: center;
  max-width: 300px;
}

.manga-img {
  width: 100%;
  height: auto;
  border-radius: 5px;
}

.manga-title {
  margin-top: 10px;
  font-size: 18px;
  color: white;
}

.error-message {
  margin-top: 10px;
  color: red;
  font-size: 14px;
}
</style>
