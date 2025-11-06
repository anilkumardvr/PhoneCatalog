
// Cursor-follow orb
(function(){
  const orb = document.getElementById('cursor-orb');
  if(!orb) return;
  let x = 0, y = 0, tx = 0, ty = 0;
  const lerp = (a,b,t)=>a+(b-a)*t;

  window.addEventListener('mousemove', (e)=>{
    tx = e.clientX; ty = e.clientY;
  });

  function frame(){
    x = lerp(x, tx, 0.15);
    y = lerp(y, ty, 0.15);
    orb.style.transform = `translate(${x-12}px, ${y-12}px)`;
    requestAnimationFrame(frame);
  }
  frame();
})();

// Small ripple on links/buttons (optional)
document.addEventListener('click', (e)=>{
  const a = e.target.closest('a,button,.btn,.card');
  if(!a) return;
  a.style.transform = 'scale(0.98)';
  setTimeout(()=> a.style.transform = '', 120);
});
