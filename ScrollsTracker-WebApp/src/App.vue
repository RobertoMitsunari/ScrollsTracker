<template>
  <header :class="{ scrolled: isScrolled, dark:isDarkMode }">
    <nav class="navbar">
      <div class="container">
        <router-link to="/" class="logo">ScrollsTracker</router-link>
        <button class="theme-btn" @click="toggleDarkMode">
          <span v-if="isDarkMode">☀️</span>
          <span v-else>🌙</span>
        </button>

        <button class="menu-btn" @click="toggleMenu">
          <span></span>
          <span></span>
          <span></span>
        </button>

        <ul :class="{ open: menuOpen }" class="nav-links">
          <li><router-link to="/">Biblioteca</router-link></li>
          <li><router-link to="/Cadastrar">Cadastrar</router-link></li>
          <li><router-link to="/About">Teste</router-link></li>
        </ul>
      </div>
    </nav>
  </header>

  <div class="main" :class="{ dark: isDarkMode }">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  data() {
    return {
      menuOpen: false,
      isDarkMode: localStorage.getItem("darkMode") === "true",
      isScrolled: false,
    };
  },
  methods: {
    toggleMenu() {
      this.menuOpen = !this.menuOpen;
    },
    toggleDarkMode() {
      this.isDarkMode = !this.isDarkMode;
      localStorage.setItem("darkMode", this.isDarkMode);
      this.$emit("darkModeChanged", this.isDarkMode);
    },
    handleScroll() {
      this.isScrolled = window.scrollY > 50;
    },
  },
  mounted() {
    window.addEventListener("scroll", this.handleScroll);
  },
  beforeUnmount() {
    window.removeEventListener("scroll", this.handleScroll);
  },
};
</script>

<style scoped>
/* css */
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

header {
  position: fixed;
  width: 100%;
  top: 0;
  left: 0;
  transition: background 0.3s ease, box-shadow 0.3s ease;
}

.navbar {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 100%;
  padding: 15px 20px;
  backdrop-filter: blur(10px);
  background: rgba(255, 255, 255, 0.8);
  transition: background 0.3s ease, box-shadow 0.3s ease;
}

header.scrolled .navbar {
  background: rgba(0, 0, 0, 0.8);
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

header.dark .navbar {
  background: rgba(30, 30, 30, 0.9);
}

.container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  max-width: 1200px;
  width: 100%;
}

.logo {
  font-size: 24px;
  font-weight: bold;
  color: #222;
  text-decoration: none;
  transition: color 0.3s ease;
}

header.dark .logo {
  color: white;
}

.nav-links {
  list-style: none;
  display: flex;
  gap: 20px;
}

.nav-links a {
  text-decoration: none;
  font-size: 18px;
  color: #222;
  transition: color 0.3s ease;
}

header.dark .nav-links a {
  color: white;
}

.nav-links a:hover {
  color: #ffcc00;
}

.theme-btn {
  background: none;
  border: none;
  font-size: 20px;
  cursor: pointer;
  transition: 0.3s;
  color: #222;
}

header.dark .theme-btn {
  color: white;
}

.menu-btn {
  display: none;
  flex-direction: column;
  gap: 5px;
  background: none;
  border: none;
  cursor: pointer;
}

.menu-btn span {
  display: block;
  width: 25px;
  height: 3px;
  background: #222;
  transition: 0.3s;
}

header.dark .menu-btn span {
  background: white;
}

@media (max-width: 768px) {
  .menu-btn {
    display: flex;
  }

  .nav-links {
    position: absolute;
    top: 60px;
    left: 0;
    width: 100%;
    background: rgba(255, 255, 255, 0.95);
    flex-direction: column;
    gap: 15px;
    padding: 15px;
    transform: translateY(-100%);
    transition: 0.3s;
  }

  header.dark .nav-links {
    background: rgba(0, 0, 0, 0.95);
  }

  .nav-links.open {
    transform: translateY(0);
  }
}

.main {
  min-height: 100vh;
  background: white;
  transition: background 0.3s ease;
}

.main.dark {
  background: #111;
  color: white;
}
</style>
