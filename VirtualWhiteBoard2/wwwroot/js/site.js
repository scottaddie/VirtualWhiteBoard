const canvas = document.getElementById('canvas');
const ctx = canvas.getContext('2d');
const canvasX = canvas.offsetLeft;
const canvasY = canvas.offsetTop;
let last_mouseX = last_mouseY = mouseX = mouseY = 0;
let isMouseDown = false;

canvas.addEventListener('mousedown', (e) => {
    last_mouseX = mouseX = parseInt(e.clientX - canvasX);
    last_mouseY = mouseY = parseInt(e.clientY - canvasY);
    isMouseDown = true;
});

canvas.addEventListener('mouseup', () => {
    isMouseDown = false;
});

canvas.addEventListener('mousemove', (e) => {
    mouseX = parseInt(e.clientX - canvasX);
    mouseY = parseInt(e.clientY - canvasY);
    const color = document.getElementById('color').value;

    if ((last_mouseX > 0 && last_mouseY > 0) && isMouseDown) {
        drawCanvas(mouseX, mouseY, last_mouseX, last_mouseY, color);
        connection.invoke('draw', last_mouseX, last_mouseY, mouseX, mouseY, color)
            .catch((err) => console.error('Unable to invoke hub\'s Draw method.', err));
    }

    last_mouseX = mouseX;
    last_mouseY = mouseY;

    document.getElementById('output').innerHTML =
        `<strong>current:</strong> ${mouseX}, ${mouseY}<br/><strong>last:</strong> ${last_mouseX}, ${last_mouseY}<br/><strong>isMouseDown:</strong> ${isMouseDown}`;
});

const connection = new signalR.HubConnectionBuilder()
    .withUrl('/draw')
    .build();

connection.on('draw', (prevX, prevY, x, y, color) => {
    drawCanvas(prevX, prevY, x, y, color);
});

connection.start()
    .catch((err) => console.error('Unable to start connection.', err));

function drawCanvas (prevX, prevY, x, y, color) {
    ctx.beginPath();
    ctx.globalCompositeOperation = 'source-over';
    ctx.strokeStyle = color;
    ctx.lineWidth = 3;
    ctx.moveTo(prevX, prevY);
    ctx.lineTo(x, y);
    ctx.lineJoin = ctx.lineCap = 'round';
    ctx.stroke();
}

function clearMousePositions () {
    last_mouseX = 0;
    last_mouseY = 0;
}