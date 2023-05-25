import { defineConfig } from "vite";
import react from "@vitejs/plugin-react";

export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      "/": {
        target: "https://localhost:7052",
        changeOrigin: false,
        secure: false,
      },
    },
  },
});
