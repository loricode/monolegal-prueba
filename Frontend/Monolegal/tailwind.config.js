/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      width:{ "5/11":"46%", "1/10":"8%" },
      flexBasis: {
        '1/10': '8%',
        '2/10': '20%',
        '5/11': '45%',
      }
    },
  },
  plugins: [],
}
