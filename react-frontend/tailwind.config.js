/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#747686",
        secondary: "#212126",
        textcolor:"white"
      },
    },
  },
  plugins: [],
}